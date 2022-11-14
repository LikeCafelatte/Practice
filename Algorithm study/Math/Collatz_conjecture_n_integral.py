# 우박수열 정적분
# https://school.programmers.co.kr/learn/courses/30/lessons/134239

def solution(k, ranges):
    answer = []
    arr = [k]
    while k != 1:
        if k % 2 == 0:
            k = k//2
        else:
            k = k * 3 + 1
        arr.append(k)
    length = len(arr)
    for left, right in ranges:
        if left - right >= length:
            answer.append(-1.0)
        else:
            answer.append(sum(arr[left:length + right]) - (arr[left] + arr[length + right - 1])/2)
    return answer