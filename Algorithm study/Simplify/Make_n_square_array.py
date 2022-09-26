# n^2 배열 자르기
# https://school.programmers.co.kr/learn/courses/30/lessons/87390?language=python3

def solution(n, left, right):
    answer = []
    for i in range(left, right + 1):
        div, mod = divmod(i, n)
        answer.append(max(div, mod) + 1)
    return answer
