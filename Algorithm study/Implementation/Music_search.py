def solution(m, musicinfos):
    answer = ['(None)', '']
    m = convertMusic(m)
    for info in musicinfos:
        key, val = toKeyVal(info)
        if not m in val:
            continue
        answer = [key, val] if len(val) > len(answer[1]) else answer
    return answer[0]

def toKeyVal(info):
    t1, t2, name, music = info.split(',')
    music = convertMusic(music)
    return name, "".join(music * (dt(t1, t2)//len(music)) + music[:(dt(t1, t2) % len(music))])

def dt(t1, t2):
    t1 = t1.split(':')
    t2 = t2.split(':')
    return (int(t2[0]) - int(t1[0])) * 60 + (int(t2[1]) - int(t1[1]) + 1)

def convertMusic(music):
    temp = []
    for val in music:
        if val == '#':
            temp.append(temp.pop().lower())
        else:
            temp.append(val)
    music = "".join(temp)
    return music
