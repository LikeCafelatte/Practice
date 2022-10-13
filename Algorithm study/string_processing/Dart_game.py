# [1차] 다트게임
# https://school.programmers.co.kr/learn/courses/30/lessons/17682

def solution(dartResult):
    res = []
    SDT = {'S':1, 'D':2, 'T':3}
    temp = ''
    for dart in dartResult:
        if dart.isdigit():
            temp += dart
        else:
            if temp:
                res.append(int(temp))
                temp = ''
            if dart in SDT.keys():
                res[-1] = res[-1] ** SDT[dart]
            elif dart == '*':
                res[-1] *= 2
                if len(res) > 1:
                    res[-2] *= 2
            else:
                res[-1] *= -1
    return sum(res)