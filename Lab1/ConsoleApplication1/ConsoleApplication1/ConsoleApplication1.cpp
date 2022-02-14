﻿#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void setFile(string name1, string name2) { //створення першого файлу, або додавання даних до нього
	ofstream fout1, fout2;
	ifstream fin1, fin2;
	cout << "Create new file = 1" << endl << "Edit file = 2" << endl;
	int n;
	cin >> n;
	cin.ignore();
	char key = 7;
	if (n == 2) {
		fout1.open(name1, fstream::app);
	}
	else if (n == 1) {
		fout1.open(name1);
	}
	fout2.open(name2);
	fin1.open(name1);
	fin2.open(name2);
	string s;
	cout << "Press G to stop setting file" << endl;
	cout << "Set first file: " << endl;
	while (true) {
		getline(cin, s);
		if (s[0] == key) {
			break;
		}
		fout1 << s << endl;
	}
	fin1.close();
	fin2.close();
	fout1.close();
	fout2.close();
}

void outputFile(string name) {//виведення з файлів
	ifstream fin;
	fin.open(name, ios::in);
	while (!fin.eof()) {
		string str;
		getline(fin, str);
		cout << str << endl;
	}
	fin.close();
}

void createFile(string name1, string name2) {// створення другого файлу
	ofstream fout1, fout2;
	ifstream fin1, fin2;
	fout1.open(name2, ios::in);
	fout2.open(name2, ios::in);
	fin1.open(name1, ios::in);
	fin2.open(name2, ios::in);
	while (!fin1.eof()) {
		string str;
		getline(fin1, str);
		int z = -1;
		for (int i = 0; i < str.size(); i++) {
			string newstr;
			int a = 0;
			if (str[i] == ' ' && str[i + 1] != '=') {
				z = i;
			}
			if (str[i] == '=') {
				a += i;
				if (z == -1) {
					for (int j = 0; j < i; j++) {
						newstr += str[j];
					}

				}
				else {
					for (int j = z + 1; j < i; j++) {
						newstr += str[j];
					}
				}
				fout2 << newstr << endl;
				break;
			}
		}
	}
	fin1.close();
	fin2.close();
	fout1.close();
	fout2.close();
}

int main()
{
	string name1 = "firstfile.txt", name2 = "secondfile.txt";
	setFile(name1, name2);
	cout << "First file:" << endl;
	outputFile(name1);
	createFile(name1, name2);
	cout << "Second file:" << endl;
	outputFile(name2);
	return 0;
}

