export class CreateTournament {

    eventId?: number
    gameId?: number

    constructor(eventId: number, gameId: number)
    {
        this.eventId = eventId
        this.gameId = gameId
    }
}