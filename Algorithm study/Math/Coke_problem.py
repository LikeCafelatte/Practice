# 콜라 문제
# https://school.programmers.co.kr/learn/courses/30/lessons/132267

def solution(a, b, n):
    answer, left = 0, 0
    while (n + left) >= a:
        n, left = ((n + left) // a) * b, (n + left) % a
        answer += n
    return answer