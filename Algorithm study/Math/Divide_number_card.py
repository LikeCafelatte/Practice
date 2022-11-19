# 숫자 카드 나누기
# https://school.programmers.co.kr/learn/courses/30/lessons/135807

import math
def solution(arrayA, arrayB):
    answer, gcdA, gcdB = 0, arrayA[0], arrayB[0]
    for a in set(arrayA):
        gcdA = math.gcd(gcdA, a)
    for b in set(arrayB):
        gcdB = math.gcd(gcdB, b)
    for a in set(arrayA):
        if a % gcdB == 0:
            break
    else:
        answer = gcdB
    for b in set(arrayB):
        if b % gcdA == 0:
            break
    else:
        answer = max(answer, gcdA)
    return answer
