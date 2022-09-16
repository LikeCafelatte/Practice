# [3차] n진수 게임
# https://school.programmers.co.kr/learn/courses/30/lessons/17687

def solution(n, t, m, p):
    calls, order = '', 0
    while len(calls) < m * (t - 1) + p:
        calls += num2base(n, order)
        order += 1
    return ''.join([calls[m * i + p - 1] for i in range(t)])
    
def num2base(n, num):
    base = {0:'0', 1:'1', 2:'2', 3:'3', 4:'4', 5:'5', 6:'6', 7:'7', 8:'8', 9:'9', 10:'A', 11:'B', 12:'C', 13:'D', 14:'E', 15:'F'}
    result = '' if num > 0 else '0'
    while num > 0:
        result = base[num % n] + result
        num = num // n
    return result
