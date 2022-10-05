# 주차 요금 계산
# https://school.programmers.co.kr/learn/courses/30/lessons/92341?language=python3

import math
def solution(fees, records):
    base_time, base_fee, step_time, step_fee = fees
    parking_lot = {}
    fees_each_car = {}
    for record in records:
        time, car, log = record.split(' ')
        hh, mm = time.split(':')
        time = int(hh) * 60 + int(mm)
        if log == 'IN':
            parking_lot[car] = time
        else:
            if car in fees_each_car.keys():
                fees_each_car[car] += time - parking_lot.pop(car)
            else:
                fees_each_car[car] = time - parking_lot.pop(car)

    for car in parking_lot.keys():
        time = 23 * 60 + 59
        if car in fees_each_car.keys():
            fees_each_car[car] += time - parking_lot[car]
        else:
            fees_each_car[car] = time - parking_lot[car]

    answer = sorted(fees_each_car.items(), key = lambda x: x[0])
    for i in range(len(answer)):
        answer[i] = base_fee + step_fee * math.ceil(max(0, answer[i][1] - base_time) / step_time)
    return answer