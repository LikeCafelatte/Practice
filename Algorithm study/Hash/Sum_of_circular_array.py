# 연속 부분 수열 합의 개수
# https://school.programmers.co.kr/learn/courses/30/lessons/131701

def solution(elements):
    ans = {}
    for i in range(1, len(elements) + 1):
        base = sum(elements[-i:])
        ans[base] = 1
        for j in range(len(elements)):
            base += elements[j] - elements[j - i]
            ans[base] = 1
    return len(ans.keys())