# 행렬과 연산
# https://school.programmers.co.kr/learn/courses/30/lessons/118670

from collections import deque
def solution(rc, operations):
    left, right, centers = deque(), deque(), deque()
    for dq in rc:
        left.append(dq[0])
        right.append(dq[-1])
        centers.append(deque(dq[1:-1]))
    operation = {"Rotate" : Rotate, "ShiftRow": ShiftRow}
    for i, oper in enumerate(operations):
        left, centers, right = operation[oper](left, centers, right)
    answer = []
    for _ in range(len(left)):
        temp = [left.popleft()] + list(centers.popleft()) + [right.popleft()]
        answer.append(temp)
    return answer
def Rotate(left, centers, right):
    top, bottom = centers.popleft(), centers.pop()
    top.appendleft(left.popleft())
    right.appendleft(top.pop())
    bottom.append(right.pop())
    left.append(bottom.popleft())
    centers.appendleft(top)
    centers.append(bottom)
    return left, centers, right
def ShiftRow(left, centers, right):
    left.rotate()
    centers.rotate()
    right.rotate()
    return left, centers, right