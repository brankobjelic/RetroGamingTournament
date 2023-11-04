type GameType = 'A'|'B'|'C'
export class Game {
    id: number
    name: string
    bannerFile: string
    gameType: GameType

    constructor( id: number, name: string, bannerFile: string, gameType: GameType)
    {
        this.id=id;
        this.name=name;
        this.bannerFile=bannerFile;
        this.gameType=gameType;
    }

}