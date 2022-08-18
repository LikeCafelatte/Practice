def solution(n):
    arr = [1, 2, 4]
    n = n - 1
    step = 1
    length = 1
    answer = ""
    while n >= step * 3:
        step *= 3
        n -= step
        length += 1
    while step >= 1:
        answer = answer + str(arr[n // step])
        n = n % step
        step = step // 3
    return answer
