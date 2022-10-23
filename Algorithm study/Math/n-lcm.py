# N개의 최소공배수
# https://school.programmers.co.kr/learn/courses/30/lessons/12953

def solution(arr):
    answer = 1
    for num in arr:
        if answer % num:
            a, b = max(answer, num), min(answer, num)
            while a % b:
                a, b = b, a % b
            answer = answer * num // b
    return answer