# 다음 큰 숫자
# https://school.programmers.co.kr/learn/courses/30/lessons/12911?language=python3

def solution(n):
    last, zero, count, binaries = -1, -1, 0, []
    while n > 0:
        n, temp = divmod(n, 2)
        if temp == 1:
            last = count
        elif last != -1:
            zero = count
            break
        count += 1
        binaries.append(temp)
    if binaries[-1] == 1:
        binaries[-1] = 0
        binaries.sort(reverse = True)
        binaries.append(1)
    else:
        binaries.append(0)
    while len(binaries) > 0:
        n = n * 2 + binaries.pop()
    return n