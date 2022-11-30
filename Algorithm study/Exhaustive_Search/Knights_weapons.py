# 기사단원의 무기
# https://school.programmers.co.kr/learn/courses/30/lessons/136798

def solution(number, limit, power):
    weapons = [0 for _ in range(number + 1)]
    limited = [False for _ in range(number + 1)]
    for i in range(1, number + 1):
        for j in range(1, number // i + 1):
            if not limited[i * j]:
                weapons[i * j] += 1
                if weapons[i * j] > limit:
                    weapons[i * j] = power
                    limited[i * j] = True
    return sum(weapons)