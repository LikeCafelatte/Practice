# 택배상자
# https://school.programmers.co.kr/learn/courses/30/lessons/131704#

def solution(order):
    answer, last, sub = 0, 0, []
    for o in order:
        if o == last + 1:
            answer += 1
            last = o
            continue
        if not sub:
            sub = list(range(1, o))
            answer += 1
            last = o
            continue
        while last < o:
            last += 1
            sub.append(last)
            continue
        if sub[-1] == o:
            sub.pop()
            answer += 1
        else:
            break
    return answer