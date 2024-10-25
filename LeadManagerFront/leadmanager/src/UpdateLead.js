import { apiClient } from "./ApiClient";

export async function UpdateLead({leadId,statusLead}) {
    try {
        const response = await apiClient.put(`Job?id=${leadId}&leadStatus=${statusLead}`);
        console.log(response.data);
    } catch (error) {
        console.error(error);
    }
}
