# 기사단원의 무기
# https://school.programmers.co.kr/learn/courses/30/lessons/136798

def solution(number, limit, power):
    answer = 0
    for i in range(1, number + 1):
        weapon = 0
        for j in range(1, i + 1):
            if i % j == 0:
                weapon += 1
                if weapon > limit:
                    weapon = power
                    break
        answer += weapon
    return answer