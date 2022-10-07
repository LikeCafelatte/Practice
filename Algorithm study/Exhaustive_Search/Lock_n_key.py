# 자물쇠와 열쇠
# https://school.programmers.co.kr/learn/courses/30/lessons/60059

def solution(key, lock):
    N, M = len(lock), len(key)
    for _ in range(4):
        for I in range(-M + 1, N):
            for J in range(-M + 1, N):
                break_trigger = False
                for i in range(0, N):
                    for j in range(0, N):
                        if max(I, 0) <= i < min(I + M, N) and max(J, 0) <= j < min(J + M, N):
                            if lock[i][j] == key[i - I][j - J]:
                                break_trigger = True
                                break
                        elif lock[i][j] == 0:
                            break_trigger = True
                            break
                    if break_trigger:
                        break
                else:
                    return True
        key = rotate(key)
    return False

def rotate(arr):
    res = []
    for temp in zip(*arr):
        res.append(list(reversed(temp)))
    return res
