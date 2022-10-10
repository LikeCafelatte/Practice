# 할인 행사
# https://school.programmers.co.kr/learn/courses/30/lessons/131127

def solution(want, number, discount):
    answer = 0
    for i in range(len(discount) - 9):
        temp = discount[i:i+10]
        for w, n in zip(want, number):
            if n != temp.count(w):
                break
        else:
            answer += 1
    return answer