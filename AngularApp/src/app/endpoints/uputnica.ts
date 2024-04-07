export interface Uputnica {
    patientId: number;
    patientName?: string;
    medicalRecords?: string;
    therapies?: Therapy[];
}

export interface Therapy {
    therapyId: number;
    therapyName: string;
    startDate: Date;
    endDate: Date;
}