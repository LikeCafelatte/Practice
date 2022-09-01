def solution(s):
    stack = []
    for char in s:
        stack.append(char) if len(stack) == 0 or stack[-1] != char else stack.pop()
    return 0 if len(stack) > 0 else 1
