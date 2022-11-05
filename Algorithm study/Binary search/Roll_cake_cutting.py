# 롤케이크 자르기
# https://school.programmers.co.kr/learn/courses/30/lessons/132265

def solution(topping):
    answer = 0
    low, high, mid = 0, len(topping) - 1, 0
    while high > low:
        mid = (low + high) // 2
        if len(set(topping[:mid])) < len(set(topping[mid:])):
            low = mid + 1
        else:
            high = mid
    answer = low
    high = len(topping) - 1
    while high > low:
        mid = (low + high) // 2
        if len(set(topping[:mid])) <= len(set(topping[mid:])):
            low = mid + 1
        else:
            high = mid
            
    return high - answer