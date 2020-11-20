import { Diagnosis } from './diagnosis';

export class FamilyIllnessHistory {
    public Relative : string;
    public Diagnosis : Array<Diagnosis>;

    constructor(relative : string, diagnosis : Array<Diagnosis>) {
        this.Relative = relative;
        this.Diagnosis = diagnosis;
    }
}