import itertools
def solution(play_time, adv_time, logs):
    get_seconds = lambda t : sum(int(val) * (60 ** (2 - idx)) for idx, val in enumerate(t.split(':')))
    play_time = get_seconds(play_time)
    adv_time = get_seconds(adv_time)
    logs = sorted(list(itertools.chain(*[[[get_seconds(val), 'in' if idx == 0 else 'out'] for idx, val in enumerate(log.split('-'))] for log in logs])))
    
    count = 0; last_time = 0; result = 0; maximum = 0; new_logs = {}; answer = 0
    for time, signal in logs:
        new_logs[(last_time, time)] = count
        count += 1 if signal == "in" else -1
        last_time = time
    if last_time < play_time:
        new_logs[(last_time, play_time)] = count
    t1 = [0, 0]; t2 = [adv_time, 0]
    keys = list(new_logs.keys())
    while t2[0] < play_time:
        while True:
            if keys[t1[1]][0] > t1[0]:
                t1[1] -= 1
            elif t1[0] >= keys[t1[1]][1]:
                t1[1] += 1
            else:
                break
        while True:
            if keys[t2[1]][0] > t2[0]:
                t2[1] -= 1
            elif t2[0] >= keys[t2[1]][1]:
                t2[1] += 1
            else:
                break
        for t in range(t1[1], t2[1] + 1):
            if t1[1] == t2[1] or (t != t1[1] and t != t2[1]):
                result += new_logs[keys[t]] * (keys[t][1] - keys[t][0])
            if t == t1[1]:
                result += new_logs[keys[t]] * (keys[t][1] - t1[0])
            elif t == t2[1]:
                result += new_logs[keys[t]] * (t2[0] - keys[t][0])
        answer = t1[0] if maximum < result else answer
        maximum = max(maximum, result); result = 0
        next_step = min(keys[t1[1]][1] - t1[0], keys[t2[1]][1] - t2[0])
        t1[0] += next_step; t2[0] += next_step
                
    return ':'.join([str(answer // 3600).zfill(2), str(answer % 3600 // 60).zfill(2), str(answer % 60).zfill(2)])

import itertools
import collections
def solution(play_time, adv_time, logs):
    get_seconds = lambda t : sum(int(val) * (60 ** (2 - idx)) for idx, val in enumerate(t.split(':')))
    play_time = get_seconds(play_time)
    adv_time = get_seconds(adv_time)
    logs = sorted(list(itertools.chain(*[[[get_seconds(val), 'in' if idx == 0 else 'out'] for idx, val in enumerate(log.split('-'))] for log in logs])))

    print(logs)
    print(play_time, adv_time)
    logs = collections.deque(logs)
    q = collections.deque()
    count = 0; last_time = 0; result = 0
    for log in logs:
        q.append(log)
        result = count * (log[0] - last_time if log[0] - last_time < adv_time else adv_time)
        if log[1] == "in":
            count += 1
        while True:
            temp = q.popleft()
            if temp[0] <= log[0] - adv_time:
                if temp[1] == "out":
                    count = max(0, count - 1)
                continue
            else:
                q.appendleft(temp)
                break;
                
        print(log, count)
    print(new_logs)
    return answer

import itertools
import collections
def solution(play_time, adv_time, logs):
    get_seconds = lambda t : sum(int(val) * (60 ** (2 - idx)) for idx, val in enumerate(t.split(':')))
    play_time = get_seconds(play_time)
    adv_time = get_seconds(adv_time)
    logs = sorted(list(itertools.chain(*[[[get_seconds(val), 'in' if idx == 0 else 'out'] for idx, val in enumerate(log.split('-'))] for log in logs])))
    
    count = 0; last_time = 0; result = 0; answer = 0; new_logs = {}
    for time, signal in logs:
        new_logs[(last_time, time)] = count
        count += 1 if signal == "in" else -1
        last_time = time
    if last_time < play_time:
        new_logs[(last_time, play_time)] = count
    t1 = [0, 0]; t2 = [adv_time, 0]
    keys = list(new_logs.keys())
    while t2[0] < play_time:
        while True:
            if keys[t1[1]][0] > t1[0]:
                t1[1] -= 1
            elif t1[0] >= keys[t1[1]][1]:
                t1[1] += 1
            else:
                break
        while True:
            if keys[t2[1]][0] > t2[0]:
                t2[1] -= 1
            elif t2[0] >= keys[t2[1]][1]:
                t2[1] += 1
            else:
                break
        for t in range(t1[1], t2[1] + 1):
            if t == t1[1]:
                result += new_logs[keys[t]] * (keys[t][1] - t)
            elif t == t2[1]:
                result += new_logs[keys[t]] * (t - keys[t][0])
            else:
                result += new_logs[keys[t]] * (keys[t][1] - keys[t][0])
        answer = max(answer, result); result = 0
        next_step = min(keys[t1[1]][1] - t1[0], keys[t2[1]][1] - t2[0])
        t1[0] += next_step; t2[0] += next_step
                
            
        
    print(new_logs)
    return answer