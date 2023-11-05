export class GamingEvent {
    id: number
    name: string
    eventDate: Date
    isActive: boolean

    constructor(id: number, name: string, eventDate: Date, isActive: boolean){
        this.id = id
        this.name = name
        this.eventDate = eventDate
        this.isActive = isActive
    }
}