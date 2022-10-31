# 옹알이(2)
# https://school.programmers.co.kr/learn/courses/30/lessons/133499

def solution(babbling):
    base = ["aya", "ye", "woo", "ma"]
    answer = 0
    for bab in babbling:
        while bab:
            if bab[:2] in base and bab[:4] != bab[:2]*2:
                bab = bab[2:]
            elif bab[:3] in base and bab[:6] != bab[:3]*2:
                bab = bab[3:]
            else:
                break
        else:
            answer += 1
    return answer