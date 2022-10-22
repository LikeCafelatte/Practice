# 점프와 순간이동
# https://school.programmers.co.kr/learn/courses/30/lessons/12980

def solution(n):
    ans = 0
    while n > 0 :
        n, r = divmod(n, 2)
        ans += r
    return ans