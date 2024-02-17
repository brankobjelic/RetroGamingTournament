export class CreateTournament {

    eventId?: number
    gameId?: number
    tournamentPlayersIds?: number[]

    constructor(eventId: number, gameId: number, tournamentPlayersIds: number[])
    {
        this.eventId = eventId
        this.gameId = gameId
        this.tournamentPlayersIds = tournamentPlayersIds
    }
}