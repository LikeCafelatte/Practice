def solution(sizes):
    answer = [0, 0]
    for size in sizes:
        answer[0] = (size[0] if answer[0] < size[0] else answer[0]) if size[0] > size[1] else (size[1] if answer[0] < size[1] else answer[0])
        answer[1] = (size[1] if answer[1] < size[1] else answer[1]) if size[0] > size[1] else (size[0] if answer[1] < size[0] else answer[1])
    return answer[0] * answer[1]