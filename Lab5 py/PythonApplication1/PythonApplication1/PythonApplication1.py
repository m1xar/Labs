import sys
from math import sqrt
import random


class TFigure:

    def __init__(self):
        self.figure = None

    def calculateS(self):
        s = 0
        figure = self.figure
        for i in range(1, len(figure)):
            s += figure[i - 1][0] * figure[i][1]
            s -= figure[i][0] * figure[i - 1][1]
        s += figure[len(figure) - 1][0] * figure[0][1]
        s -= figure[0][0] * figure[len(figure) - 1][1]
        return abs(s) / 2

    def calculateP(self):
        p = 0
        figure = self.figure
        for i in range(len(figure) - 1):
            line = 0
            line = sqrt((figure[i + 1][0] - figure[i][0]) ** 2 + (figure[i + 1][1] - figure[i][1]) ** 2)
            p += line
        p += sqrt((figure[0][0] - figure[len(figure) - 1][0]) ** 2 + (figure[0][1] - figure[len(figure) - 1][1]) ** 2)
        return p
    def outFigure(self):
        figure = self.figure
        counter = 1
        for i in range(len(figure)):
            print(f"Point number {counter}: x = {figure[i][0]} y = {figure[i][1]}")



class THexagon(TFigure):

    def __init__(self, rand_key=False):
        super().__init__()
        if rand_key:
            arr = [[random.random() * 10 for i in range(2)] for j in range(6)]
        else:
            print("Set your hexagon: ")
            arr = []
            for i in range(6):
                print("Point {}: ".format(i + 1))
                arr.append([])
                for j in range(2):
                    if j == 0:
                        num = float(input("X = "))
                    else:
                        num = float(input("Y = "))
                    arr[i].append(num)
        self.figure = arr


class TPentagon(TFigure):

    def __init__(self, rand_key=False):
        super().__init__()
        if rand_key:
            arr = [[random.random() * 10 for i in range(2)] for j in range(5)]
        else:
            print("Set your hexagon: ")
            arr = []
            for i in range(5):
                print("Point {}: ".format(i + 1))
                arr.append([])
                for j in range(2):
                    if j == 0:
                        num = float(input("X = "))
                    else:
                        num = float(input("Y = "))
                    arr[i].append(num)
        self.figure = arr


def create_pentagones(n):
    arr = []
    for i in range(n):
        ans = input("Do you want to set this pentagone automatically? (+ or -) : ")
        if ans == "+":
            arr.append(TPentagon(True))
        else:
            arr.append(TPentagon())
    return arr


def create_hexagones(m):
    arr = []
    for i in range(m):
        ans = input("Do you want to set this hexagone automatically? (+ or -) : ")
        if ans == "+":
            arr.append(THexagon(True))
        else:
            arr.append(THexagon())
    return arr

def maxP(pentas, n):
    p = 0
    index = 0
    for i in range(n):
        if pentas[i].calculateP() > p:
            index = i + 1
            p = pentas[i].calculateP()
    return index

def minS(hexas, m):
    s = sys.float_info.max
    index = 0
    for i in range(m):
        if hexas[i].calculateS() < s:
            index = i + 1
            s = hexas[i].calculateS()
    return index

def outHexas(arr):
    for i in range(len(arr)):
        print(f"Hexagone number {i+1}:")
        arr[i].outFigure()

def outPentas(arr):
    for i in range(len(arr)):
        print(f"Pentagone number {i+1}:")
        arr[i].outFigure()


def main():
    n = int(input("Set number of pentagones: "))
    pentagones = create_pentagones(n)
    m = int(input("Set number of hexagones: "))
    hexagones = create_hexagones(m)
    min_square = minS(hexagones, m)
    max_perim = maxP(pentagones, n)
    outPentas(pentagones)
    outHexas(hexagones)
    print(f"Hexagone number {min_square} have the least area! It is equal to {hexagones[min_square-1].calculateS()}")
    print(f"Pentagone number {max_perim} have the greatest perimeter! It is equal to {pentagones[max_perim-1].calculateP()}")


main()