import React from 'react';
import { Page, Text, View, Document, StyleSheet, Font } from '@react-pdf/renderer';

// Register a standard font (you can add more fonts if needed)
Font.register({
    family: 'Helvetica',
    fonts: [
        { src: 'https://fonts.gstatic.com/s/helveticaneue/v70/1Ptsg8zYS_SKggPNyCg4TYFv.ttf' },
        { 
            src: 'https://fonts.gstatic.com/s/helveticaneue/v70/1Ptsg8zYS_SKggPNyCg4QYFv.ttf',
            fontWeight: 'bold' 
        }
    ]
});

// Create styles
const styles = StyleSheet.create({
    page: {
        padding: 30,
        fontFamily: 'Helvetica'
    },
    header: {
        fontSize: 18,
        textAlign: 'center',
        marginBottom: 20,
        fontWeight: 'bold'
    },
    section: {
        margin: 10,
        padding: 10,
        flexGrow: 1
    },
    row: {
        flexDirection: 'row',
        marginBottom: 10
    },
    label: {
        width: 150,
        fontWeight: 'bold'
    },
    value: {
        flex: 1
    },
    footer: {
        position: 'absolute',
        bottom: 30,
        left: 30,
        right: 30
    }
});

const InspectionCertificateTemplate = ({ inspection }) => (
    <Document>
        <Page size="A4" style={styles.page}>
            <Text style={styles.header}>Plant Inspection Certificate</Text>
            
            <View style={styles.section}>
                <View style={styles.row}>
                    <Text style={styles.label}>Plant Description:</Text>
                    <Text style={styles.value}>{inspection.plantDescription || ''}</Text>
                </View>
                
                <View style={styles.row}>
                    <Text style={styles.label}>Serial Number:</Text>
                    <Text style={styles.value}>{inspection.serialNumber || ''}</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Location:</Text>
                    <Text style={styles.value}>{inspection.location || ''}</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Inspection Date:</Text>
                    <Text style={styles.value}>
                        {inspection.inspectionDate ? new Date(inspection.inspectionDate).toLocaleDateString('en-GB') : ''}
                    </Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Vehicle Inspected On:</Text>
                    <Text style={styles.value}>{inspection.vehicleInspectedOn || ''}</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Recent Check:</Text>
                    <Text style={styles.value}>{inspection.recentCheck || ''}</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Previous Check:</Text>
                    <Text style={styles.value}>{inspection.previousCheck || ''}</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Safe Working:</Text>
                    <Text style={styles.value}>{inspection.safeWorking || ''}</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Defects:</Text>
                    <Text style={styles.value}>{inspection.defects || ''}</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Rectified:</Text>
                    <Text style={styles.value}>{inspection.rectified || ''}</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Latest Date:</Text>
                    <Text style={styles.value}>
                        {inspection.latestDate ? new Date(inspection.latestDate).toLocaleDateString('en-GB') : ''}
                    </Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Test Details:</Text>
                    <Text style={styles.value}>{inspection.testDetails || ''}</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.label}>Miscellaneous Notes:</Text>
                    <Text style={styles.value}>{inspection.miscNotes || ''}</Text>
                </View>
            </View>

            <View style={styles.footer}>
                <View style={styles.row}>
                    <Text style={styles.label}>Inspector:</Text>
                    <Text style={styles.value}>_________________________</Text>
                </View>
                <View style={styles.row}>
                    <Text style={styles.label}>Date:</Text>
                    <Text style={styles.value}>_________________________</Text>
                </View>
            </View>
        </Page>
    </Document>
);

export default InspectionCertificateTemplate;