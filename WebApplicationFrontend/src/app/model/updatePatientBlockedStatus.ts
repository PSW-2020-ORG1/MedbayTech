export class UpdatePatientBlockedStatus {
    id: string;
    blocked: boolean;

    constructor(id: string, blocked: boolean){
        this.id = id;
        this.blocked = blocked;
    }
}