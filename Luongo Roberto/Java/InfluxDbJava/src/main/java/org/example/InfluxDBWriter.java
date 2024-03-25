package org.example;

//import java.time.Instant;
//import java.util.stream.Stream;
//import com.influxdb.v3.client.write.Point;
//import com.influxdb.v3.client.write.WriteOptions;
//import com.influxdb.v3.client.InfluxDBClient;
//import com.influxdb.v3.client.InfluxDBClientFactory;
//
////"z0cj0akYOwMgxXEBgza61TLe_80tHZ-WNDcoWYJaGb0gvLFsAMckWrNJHmBRGmBFxHjbxg_o0gwnHI5RSiW2vg=="
//
//public class Main {
//    public static void main(final String[] args) throws Exception {
//
//        String hostUrl = "https://eu-central-1-1.aws.cloud2.influxdata.com";
//
//        var authToken = "z0cj0akYOwMgxXEBgza61TLe_80tHZ-WNDcoWYJaGb0gvLFsAMckWrNJHmBRGmBFxHjbxg_o0gwnHI5RSiW2vg==";
//        char[] authToken = System.getenv("z0cj0akYOwMgxXEBgza61TLe_80tHZ-WNDcoWYJaGb0gvLFsAMckWrNJHmBRGmBFxHjbxg_o0gwnHI5RSiW2vg==").toCharArray();
//        String database = "new_bucket";
//        //influxDBClient client = new influxDBClient(hostUrl, authToken.toCharArray());
//
//        InfluxDBClient client = new InfluxDBClient(hostUrl, authToken.toCharArray();
//        try {
//
//            Point[] points = new Point[] {
//                    Point.measurement("census")
//                            .addTag("location", "Klamath")
//                            .addField("bees", 23),
//                    Point.measurement("census")
//                            .addTag("location", "Portland")
//                            .addField("ants", 30),
//                    Point.measurement("census")
//                            .addTag("location", "Klamath")
//                            .addField("bees", 28),
//                    Point.measurement("census")
//                            .addTag("location", "Portland")
//                            .addField("ants", 32),
//                    Point.measurement("census")
//                            .addTag("location", "Klamath")
//                            .addField("bees", 29),
//                    Point.measurement("census")
//                            .addTag("location", "Portland")
//                            .addField("ants", 40)
//            };
//
//            for (Point point : points) {
//                client.writePoint(point, new WriteOptions.Builder().database(database).build());
//                Thread.sleep(1000); // separate points by 1 second
//            }
//            System.out.println("Complete. Return to the InfluxDB UI.");
//        }
//        catch (Exception e) {
//            System.out.println("Error: " + e.getMessage());
//        }
//    }
//}
import com.influxdb.v3.client.InfluxDBClient;
//import com.influxdb.v3.client.InfluxDBClientFactory;
import com.influxdb.v3.client.query.QueryOptions;
import com.influxdb.v3.client.write.Point;
import com.influxdb.v3.client.write.WritePrecision;
import com.influxdb.v3.client.write.WriteOptions;
import com.influxdb.v3.client.query.QueryType;
import com.influxdb.v3.client.query.QueryOptions;

import java.util.stream.Stream;

public class InfluxDBWriter {
    public static void main(String[] args) {
        String hostUrl = "https://eu-central-1-1.aws.cloud2.influxdata.com";
        String authToken = "z0cj0akYOwMgxXEBgza61TLe_80tHZ-WNDcoWYJaGb0gvLFsAMckWrNJHmBRGmBFxHjbxg_o0gwnHI5RSiW2vg==";
        String bucket = "new_bucket";

//        try (InfluxDBClient client = InfluxDBClient.getInstance(hostUrl, authToken.toCharArray(), bucket)) {
//            String database = "new_bucket";
//
//            Point[] points = new Point[] {
//                    Point.measurement("census")
//                            .addTag("location", "Klamath")
//                            .addField("bees", 23),
//                    Point.measurement("census")
//                            .addTag("location", "Portland")
//                            .addField("ants", 30),
//                    Point.measurement("census")
//                            .addTag("location", "Klamath")
//                            .addField("bees", 28),
//                    Point.measurement("census")
//                            .addTag("location", "Portland")
//                            .addField("ants", 32),
//                    Point.measurement("census")
//                            .addTag("location", "Klamath")
//                            .addField("bees", 29),
//                    Point.measurement("census")
//                            .addTag("location", "Portland")
//                            .addField("ants", 40)
//            };
//
//            for (Point point : points) {
//                client.writePoint(point, new WriteOptions.Builder().database(database).build());
//                System.out.println("Write point");
//                Thread.sleep(1000); // separate points by 1 second
//            }
//
//            System.out.println("Complete. Return to the InfluxDB UI.");
//        }
//        catch (Exception e) {
//            System.out.println("Error: " + e.getMessage());
//        }
        String sql = "SELECT * " +
                "FROM 'census' " +
                "WHERE time >= now() - interval '1 hour' " +
                "AND ('bees' IS NOT NULL OR 'ants' IS NOT NULL) order by time asc";

        System.out.printf("| %-5s | %-5s | %-8s | %-30s |%n", "ants", "bees", "location", "time");
        try (InfluxDBClient client = InfluxDBClient.getInstance(hostUrl, authToken.toCharArray(), bucket)) {
            String database = "new_bucket";
            try (Stream<Object[]> stream = client.query(sql, new QueryOptions(bucket, QueryType.SQL))) {
                stream.forEach(row -> System.out.printf("| %-5s | %-5s | %-8s | %-30s |%n", row[0], row[1], row[2], row[3]));
            }
        }
        catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}