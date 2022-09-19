# 피보나치 수
# https://school.programmers.co.kr/learn/courses/30/lessons/12945

import sys
sys.setrecursionlimit(1000000000)
table = [0, 1]
def solution(n):
    return pibonacci(n) % 1234567
def pibonacci(n):
    if len(table) > n:
        return table[n]
    else:
        result = pibonacci(n - 1) + pibonacci(n - 2)
        table.append(result)
        return result
