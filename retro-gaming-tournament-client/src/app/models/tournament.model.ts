import { Game } from "./game.model"
import { GamingEvent } from "./gaming-event.model"

export class Tournament {
    id: number
    isActive: boolean
    eventId: number
    eventName: string
    gameId: number
    gameName: string

    constructor(id: number, isActive: boolean, eventId: number, eventName: string, gameId: number, gameName: string)
    {
        this.id = id
        this.isActive = isActive
        this.eventId = eventId
        this.eventName = eventName
        this.gameId = gameId
        this.gameName = gameName
    }
}