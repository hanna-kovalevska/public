import pygame

bg = pygame.image.load('fill.png')
list = [[[1, 2, 1, 2], [3, 3, 4, 2], [4, 3, 3, 4], [2, 4, 1, 1], [0, 0, 0, 0], [0, 0, 0, 0]],
        [[1, 4, 1, 3], [3, 2, 3, 2], [1, 4, 4, 2], [1, 4, 2, 3], [0, 0, 0, 0], [0, 0, 0, 0]],
        [[4, 4, 3, 1], [2, 2, 2, 1], [2, 3, 3, 1], [3, 1, 4, 4], [0, 0, 0, 0], [0, 0, 0, 0]],
        [[4, 2, 4, 1], [2, 1, 3, 4], [3, 3, 2, 1], [3, 1, 2, 4], [0, 0, 0, 0], [0, 0, 0, 0]],
        [[4, 1, 1, 4], [2, 2, 1, 3], [3, 2, 2, 3], [4, 1, 4, 3], [0, 0, 0, 0], [0, 0, 0, 0]]]
now = list[0]
level = [False, False, False, False, False]
new_c = 0
new_p = 0
lvl = 0
text = ''

pygame.init()
win = pygame.display.set_mode((800, 400))
pygame.display.set_caption("Cats Sort Puzzle")
cat = [pygame.image.load('cat_0.jpg'), pygame.image.load('cat_1.jpg'), pygame.image.load('cat_2.jpg'),
       pygame.image.load('cat_3.jpg'), pygame.image.load('cat_4.jpg')]
style_text = pygame.font.SysFont('serif', 36)
style_g = pygame.font.SysFont('serif', 48)


def drawWind():
    win.blit(bg, (0, 0))
    for i in range(6):
        for j in range(4):
            win.blit(cat[now[i][j]], (44 + 111 * i, 280 - j * 60))
    win.blit(cat[new_c], (44 + 111 * new_p, 40))
    win.blit(style_g.render(text, False, (207, 0, 92)), (30, 30))
    for i in range(5):
        if level[i]:
            pygame.draw.circle(win, (0, 189, 0), (735, 40 + 80 * i), 30, 3)
        else:
            pygame.draw.circle(win, (64, 128, 255), (735, 40 + 80 * i), 30, 3)
        win.blit(style_text.render(str(i + 1), False, (0, 4, 124)), (726, 22 + 80 * i))
    pygame.display.update()


def upCat(t):
    global new_p, new_c, now
    if now[t][0] != 0:
        i = 3
        while now[t][i] == 0:
            i = i - 1
        new_c = now[t][i]
        new_p = t
        now[t][i] = 0


def downCat(t):
    global new_p, new_c, now
    if t != new_p:
        if now[t][0] == 0:
            now[t][0] = new_c
            new_c = 0
        elif now[t][3] == 0:
            i = 2
            while now[t][i] == 0:
                i = i - 1
            if now[t][i] == new_c:
                now[t][i + 1] = new_c
                new_c = 0


def returnCat():
    global new_p, new_c, now
    if now[new_p][0] != 0:
        i = 3
        while now[new_p][i] == 0:
            i = i - 1
        now[new_p][i + 1] = new_c
        new_c = 0
    else:
        now[new_p][0] = new_c
        new_c = 0


def Check():
    global play, now, text
    look = True
    for i in range(6):
        for j in range(3):
            if now[i][j] != now[i][3]:
                look = False
    if look:
        level[lvl] = True

    look = True
    for i in range(5):
        if not level[i]:
            look = False
    if look:
        text = 'You win!!!'

def changeLevel(pos):
    global lvl, now, new_c
    if 765 > pos[0] > 705:
        if (pos[1] - 10) % 80 < 60:
            if new_c != 0:
                returnCat()
            lvl = (pos[1] - 10) // 80
            now = list[lvl]


play = True
while play:
    pygame.time.delay(100)
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            play = False
        elif event.type == pygame.KEYDOWN:
            if new_c == 0:
                if event.key == pygame.K_1:
                    upCat(0)
                if event.key == pygame.K_2:
                    upCat(1)
                if event.key == pygame.K_3:
                    upCat(2)
                if event.key == pygame.K_4:
                    upCat(3)
                if event.key == pygame.K_5:
                    upCat(4)
                if event.key == pygame.K_6:
                    upCat(5)
            else:
                if event.key == pygame.K_1:
                    downCat(0)
                if event.key == pygame.K_2:
                    downCat(1)
                if event.key == pygame.K_3:
                    downCat(2)
                if event.key == pygame.K_4:
                    downCat(3)
                if event.key == pygame.K_5:
                    downCat(4)
                if event.key == pygame.K_6:
                    downCat(5)
                if event.key == pygame.K_z:
                    returnCat()
        elif event.type == pygame.MOUSEBUTTONDOWN:
            if event.button == 1:
                changeLevel(event.pos)
    drawWind()
    Check()
