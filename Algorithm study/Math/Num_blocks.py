# 숫자 블록
# https://school.programmers.co.kr/learn/courses/30/lessons/12923#

def solution(begin, end):
    answer = []
    for i in range(begin, end + 1):
        answer.append(0)
        if i > 1:
            for j in range(2, int(i ** 0.5) + 1):
                if i%j == 0:
                    if i // j <= 10000000:
                        answer[-1] = i // j
                        break
                    else:
                        answer[-1] = j
            else:
                answer[-1] = 1
    return answer