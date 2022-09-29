# [3차] 압축
# https://school.programmers.co.kr/learn/courses/30/lessons/17684?language=python3

def solution(msg):
    answer = []
    dictionary = {val : idx + 1 for idx, val in enumerate('ABCDEFGHIJKLMNOPQRSTUVWXYZ')}
    temp_str = ''
    for c in msg:
        temp_str += c
        if not temp_str in dictionary:
            dictionary[temp_str] = len(dictionary.keys()) + 1
            answer.append(dictionary[temp_str[:-1]])
            temp_str = c
    answer.append(dictionary[temp_str])
    return answer
