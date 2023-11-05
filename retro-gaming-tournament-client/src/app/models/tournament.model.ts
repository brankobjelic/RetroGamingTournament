import { Game } from "./game.model"
import { GamingEvent } from "./gaming-event.model"

export class Tournament {
    id: number
    isActive: boolean
    event: GamingEvent
    game: Game

    constructor(id: number, isActive: boolean, event: GamingEvent, game: Game)
    {
        this.id = id
        this.isActive = isActive
        this.event = event
        this.game = game
    }
}