# 전화번호 목록
# https://school.programmers.co.kr/learn/courses/30/lessons/42577?language=python3

def solution(phone_book):
    temp = 'Null'
    for phone in sorted(phone_book):
        if phone[:len(temp)] == temp:
            return False
        else:
            temp = phone
    return True
