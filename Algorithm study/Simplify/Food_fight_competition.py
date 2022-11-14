# 푸드 파이트 대회
# https://school.programmers.co.kr/learn/courses/30/lessons/134240

def solution(food):
    a, b = '', ''
    for idx, val in enumerate(food):
        a, b = a + str(idx) * (val // 2), str(idx) * (val // 2) + b
    return a + '0' + b