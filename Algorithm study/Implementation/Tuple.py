# 튜플
# https://school.programmers.co.kr/learn/courses/30/lessons/64065

def solution(s):
    answer = []
    for arr in sorted([[int(n) for n in t.split(',') if n.isdigit()] for t in s[2:-2].split('},{')], key = lambda x: len(x)):
        for element in arr:
            if not element in answer:
                answer.append(element)
    return answer