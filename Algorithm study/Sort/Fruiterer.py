# 과일 장수
# https://school.programmers.co.kr/learn/courses/30/lessons/135808

def solution(k, m, score):
    answer, score = 0, sorted(score, reverse = True)
    for i in range(len(score)//m):
        answer += m * score[m - 1 + m * i]
    return answer
