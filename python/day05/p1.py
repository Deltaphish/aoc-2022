
preamble = []
instructions = []

# Read Input
with open("input", "r") as f:
    switch = False
    while l := f.readline():
        if (not switch) and '1' in l:
            switch = True
            continue
        
        if switch:
            instructions.append(l.strip())
        else:
            preamble.append(l)

#Parse Preamble
column_count = preamble[-1].count('[')
column_indicies = [(i*4+1) for i in range(column_count)]

columns = [[] for i in range(column_count)]

for line in preamble:
    for i, c in enumerate(column_indicies):
        if line[c] != ' ':
            columns[i].append(line[c])

#Interpret instructions
instructions = instructions[1:]
values = [[int(s[1]),int(s[3]),int(s[5])] for s in [c.split(' ') for c in instructions]]

def eval_instruction(inst,columns):
    for i in range(inst[0]):
        columns[inst[2]-1] = [columns[inst[1]-1][0]] + columns[inst[2]-1]
        columns[inst[1]-1] = columns[inst[1]-1][1:]
    return columns

for l in values:
    print(columns)
    columns = eval_instruction(l, columns)

# Get top crates
print([c[0] for c in columns])