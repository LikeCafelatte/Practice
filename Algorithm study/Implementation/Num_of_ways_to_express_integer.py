# 숫자의 표현
# https://school.programmers.co.kr/learn/courses/30/lessons/12924

def solution(n):
    left, temp, answer = 0, 0, 0
    for i in range(1, n + 1):
        temp += i
        while temp > n:
            temp -= left
            left += 1
        if temp == n:
            answer += 1
    return answer
