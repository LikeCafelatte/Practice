# 하노이의 탑
# https://school.programmers.co.kr/learn/courses/30/lessons/12946?language=python3

def solution(n):
    return dp([1, 2, 3], n)
def dp(ref, n):
    a, b, c = ref
    if n == 1:
        return [[a, c]]
    return dp([a, c ,b], n - 1) + [[a, c]] + dp([b, a, c], n - 1)
