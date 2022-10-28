# 괄호 변환
# https://school.programmers.co.kr/learn/courses/30/lessons/60058?language=python3

def solution(p):
    answer = sol(p)
    return answer

def sol(s):
    if len(s) == 0:
        return s
    cnt, u, v = 0, '', ''
    uIsCorrect = True
    for idx, val in enumerate(s):
        if val == ')':
            cnt += -1
        else:
            cnt += 1
        u += val
        if cnt == 0:
            v = s[idx + 1:]
            break
        elif cnt < 0:
            uIsCorrect = False
    
    if uIsCorrect:
        return u + sol(v)
    else:
        temp = ''
        for c in u[1:-1]:
            temp += '(' if c == ')' else ')'
        return '(' + sol(v) + ')' + temp