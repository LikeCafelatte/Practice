# 멀리뛰기
# https://school.programmers.co.kr/learn/courses/30/lessons/12914

def solution(n):
    a, b = 1, 1
    for _ in range(1, n):
        a, b = b % 1234567, (a + b) % 1234567
    return b