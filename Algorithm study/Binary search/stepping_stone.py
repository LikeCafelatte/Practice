# 징검다리 건너기
# https://school.programmers.co.kr/learn/courses/30/lessons/64062/solution_groups?language=python3

from collections import deque
def solution(stones, k):
    low, high = min(stones), max(stones)
    lists = [stones]
    while high > low:
        mid = (high + low) // 2
        temp_lists = []
        for new_list in lists:
            temp = []
            for stone in new_list:
                if stone > mid:
                    if len(temp) >= k:
                        temp_lists.append(temp)
                    temp = []
                else:
                    temp.append(stone)
            if len(temp) >= k:
                temp_lists.append(temp)
            temp = []
        if len(temp_lists) > 0:
            high = mid
            lists = temp_lists
        else:
            low = mid + 1
    return low
