export class Game {
    id: number
    name: string
    bannerFile: string
    numberOfPlayers: number

    constructor( id: number, name: string, bannerFile: string, numberOfPlayers: number)
    {
        this.id=id;
        this.name=name;
        this.bannerFile=bannerFile;
        this.numberOfPlayers=numberOfPlayers;
    }

}