export class CreateTournament {

    gamingEventId?: number
    gameId?: number

    constructor(gamingEventId: number, gameId: number)
    {
        this.gamingEventId = gamingEventId
        this.gameId = gameId
    }
}