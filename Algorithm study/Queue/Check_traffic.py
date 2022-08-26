from collections import deque
from datetime import datetime,timedelta
from decimal import Decimal
def solution(lines):
    answer = 0
    logs = []
    onesec = timedelta(seconds = 1)
    for line in lines:
        processing_time = line.split(' ')[-1]
        delta = timedelta(seconds = float(Decimal(processing_time.replace("s", "")) - Decimal('0.001')))
        line = line.replace(" " + processing_time, "")
        time = datetime.strptime(line, '%Y-%m-%d %H:%M:%S.%f')
        logs.extend([[(time - delta), "in"], [time, "out"]])
    
    logs.sort(key = lambda row : row[0])
    logs = deque(logs)
    q = deque()
    count = 0
    for log in logs:
        q.append(log)
        if log[1] == "in":
            count += 1
        while True:
            temp = q.popleft()
            if temp[0] <= log[0] - onesec:
                if temp[1] == "out":
                    count = max(0, count - 1)
                continue
            else:
                q.appendleft(temp)
                break;
        answer = max(answer, count)
    
    return answer
