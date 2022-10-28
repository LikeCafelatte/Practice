# 햄버거 만들기
# https://school.programmers.co.kr/learn/courses/30/lessons/133502?language=python3

def solution(ingredient):
    answer, stack = 0, []
    for i in ingredient:
        if not stack:
            stack.append([])
        if i == 1:
            if not stack[-1]:
                stack[-1].append(i)
            elif stack[-1][-1] == 3:
                stack.pop()
                answer += 1
            else:
                stack.append([i])
        else:
            if stack[-1] and i == stack[-1][-1] + 1:
                stack[-1].append(i)
            else:
                stack = [[]]
            
    return answer