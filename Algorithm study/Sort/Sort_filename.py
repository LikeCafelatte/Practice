# [3차] 파일명 정렬
# https://school.programmers.co.kr/learn/courses/30/lessons/17686

from functools import cmp_to_key
def solution(files):
    files.sort(key = cmp_to_key(cmp_fun))
    return files
def cmp_fun(x, y):
    x, y = str2hnt(x), str2hnt(y)
    if x[0].lower() > y[0].lower():
        return 1
    elif x[0].lower() == y[0].lower():
        if x[1] > y[1]:
            return 1
        elif x[1] == y[1]:
            return 0
        else:
            return -1
    else:
        return -1
def str2hnt(x):
    temp_x = []
    temp = ''
    for i, s in enumerate(x):
        if s.isdigit():
            if len(temp_x) == 0:
                temp_x.append(temp)
                temp = 0
            temp = temp * 10 + int(s)
            if i == len(x) - 1:
                temp_x.append(temp)
                temp = ''
                break
        else:
            if len(temp_x) == 1:
                temp_x.append(temp)
                temp = ''
                break
            temp += s
    return temp_x